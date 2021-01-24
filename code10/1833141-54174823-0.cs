    using System;
    using System.Collections;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace CustomViewbox
    {
        /// <summary>
        /// Returns an Enumerator that enumerates over nothing.
        /// </summary>
        internal class EmptyEnumerator : IEnumerator
        {
            // singleton class, private ctor
            private EmptyEnumerator()
            {
            }
            /// <summary>
            /// Read-Only instance of an Empty Enumerator.
            /// </summary>
            public static IEnumerator Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new EmptyEnumerator();
                    }
                    return _instance;
                }
            }
            /// <summary>
            /// Does nothing.
            /// </summary>
            public void Reset() { }
            /// <summary>
            /// Returns false.
            /// </summary>
            /// <returns>false</returns>
            public bool MoveNext() { return false; }
    #pragma warning disable 1634, 1691  // about to use PreSharp message numbers - unknown to C#
            /// <summary>
            /// Returns null.
            /// </summary>
            public object Current
            {
                get
                {
    #pragma warning disable 6503 // "Property get methods should not throw exceptions."
                    throw new InvalidOperationException();
    #pragma warning restore 6503
                }
            }
    #pragma warning restore 1634, 1691
            private static IEnumerator _instance;
        }
        internal class SingleChildEnumerator : IEnumerator
        {
            internal SingleChildEnumerator(object Child)
            {
                _child = Child;
                _count = Child == null ? 0 : 1;
            }
            object IEnumerator.Current
            {
                get { return (_index == 0) ? _child : null; }
            }
            bool IEnumerator.MoveNext()
            {
                _index++;
                return _index < _count;
            }
            void IEnumerator.Reset()
            {
                _index = -1;
            }
            private int _index = -1;
            private int _count = 0;
            private object _child;
        }
        /// <summary>
        /// </summary>
        public class Viewbox : Decorator
        {
            //-------------------------------------------------------------------
            //
            //  Constructors
            //
            //-------------------------------------------------------------------
            #region Constructors
            /*static Viewbox()
            {
                ControlsTraceLogger.AddControl(TelemetryControls.ViewBox);
            }*/
            /// <summary>
            ///     Default DependencyObject constructor
            /// </summary>
            /// <remarks>
            ///     Automatic determination of current Dispatcher. Use alternative constructor
            ///     that accepts a Dispatcher for best performance.
            /// </remarks>
            public Viewbox() : base()
            {
            }
            #endregion
            //-------------------------------------------------------------------
            //
            //  Public Fields
            //
            //-------------------------------------------------------------------
            #region Public Fields
            /// <summary>
            /// This is the DependencyProperty for the Viewbox's Stretch property.
            ///
            /// Default:  Stretch.Uniform
            /// <seealso cref="Viewbox.Stretch" />
            /// </summary>
            public static readonly DependencyProperty StretchProperty
                = DependencyProperty.Register(
                    "Stretch",          // Property name
                    typeof(Stretch),    // Property type
                    typeof(Viewbox),    // Property owner
                    new FrameworkPropertyMetadata(Stretch.Uniform, FrameworkPropertyMetadataOptions.AffectsMeasure),
                    new ValidateValueCallback(ValidateStretchValue));
            private static bool ValidateStretchValue(object value)
            {
                Stretch s = (Stretch)value;
                return (s == Stretch.Uniform
                        || s == Stretch.None
                        || s == Stretch.Fill
                        || s == Stretch.UniformToFill);
            }
            #endregion
            //-------------------------------------------------------------------
            //
            //  Public Methods
            //
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            //
            //  Public Properties
            //
            //-------------------------------------------------------------------
            #region Public Properties
            private ContainerVisual InternalVisual
            {
                get
                {
                    if (_internalVisual == null)
                    {
                        _internalVisual = new ContainerVisual();
                        AddVisualChild(_internalVisual);
                    }
                    return _internalVisual;
                }
            }
            private UIElement InternalChild
            {
                get
                {
                    VisualCollection vc = InternalVisual.Children;
                    if (vc.Count != 0) return vc[0] as UIElement;
                    else return null;
                }
                set
                {
                    VisualCollection vc = InternalVisual.Children;
                    if (vc.Count != 0) vc.Clear();
                    vc.Add(value);
                }
            }
            private Transform InternalTransform
            {
                get
                {
                    return InternalVisual.Transform;
                }
                set
                {
                    InternalVisual.Transform = value;
                }
            }
            /// <summary>
            /// The single child of a <see cref="Viewbox" />
            /// </summary>
            public override UIElement Child
            {
                //everything is the same as on Decorator, the only difference is to insert intermediate Visual to
                //specify scaling transform
                get
                {
                    return InternalChild;
                }
                set
                {
                    UIElement old = InternalChild;
                    if (old != value)
                    {
                        //need to remove old element from logical tree
                        RemoveLogicalChild(old);
                        if (value != null)
                        {
                            AddLogicalChild(value);
                        }
                        InternalChild = value;
                        InvalidateMeasure();
                    }
                }
            }
            /// <summary>
            /// Returns the Visual children count.
            /// </summary>
            protected override int VisualChildrenCount
            {
                get { return 1; /* Always have internal container visual */ }
            }
            /// <summary>
            /// Returns the child at the specified index.
            /// </summary>
            protected override Visual GetVisualChild(int index)
            {
                if (index != 0)
                {
                    throw new ArgumentOutOfRangeException(/*"index", index, SR.Get(SRID.Visual_ArgumentOutOfRange)*/);
                }
                return InternalVisual;
            }
            /// <summary>
            /// Returns enumerator to logical children.
            /// </summary>
            protected override IEnumerator LogicalChildren
            {
                get
                {
                    if (InternalChild == null)
                    {
                        return EmptyEnumerator.Instance;
                    }
                    return new SingleChildEnumerator(InternalChild);
                }
            }
            /// <summary>
            /// Gets/Sets the Stretch mode of the Viewbox, which determines how the content will be
            /// fit into the Viewbox's space.
            ///
            /// </summary>
            /// <seealso cref="Viewbox.StretchProperty" />
            /// <seealso cref="Stretch" />
            public Stretch Stretch
            {
                get { return (Stretch)GetValue(StretchProperty); }
                set { SetValue(StretchProperty, value); }
            }
            #endregion Public Properties
            //-------------------------------------------------------------------
            //
            //  Protected Methods
            //
            //-------------------------------------------------------------------
            #region Protected Methods
            /// <summary>
            /// Updates DesiredSize of the Viewbox.  Called by parent UIElement.  This is the first pass of layout.
            /// </summary>
            /// <remarks>
            /// Viewbox measures it's child at an infinite constraint; it allows the child to be however large it so desires.
            /// The child's returned size will be used as it's natural size for scaling to Viewbox's size during Arrange.
            /// </remarks>
            /// <param name="constraint">Constraint size is an "upper limit" that the return value should not exceed.</param>
            /// <returns>The Decorator's desired size.</returns>
            protected override Size MeasureOverride(Size constraint)
            {
                var child = InternalChild;
                var parentSize = new Size();
                if (child != null)
                {
                    // Initialize child constraint to infinity.  We need to get a "natural" size for the child in absence of constraint.
                    // Note that an author *can* impose a constraint on a child by using Height/Width, &c... properties 
                    var infiniteConstraint = new Size(double.PositiveInfinity, double.PositiveInfinity);
                    child.Measure(infiniteConstraint);
                    var childSize = child.DesiredSize;
                    var scalefac = ComputeScaleFactor(constraint, childSize, Stretch);
                    parentSize.Width = scalefac * childSize.Width;
                    parentSize.Height = scalefac * childSize.Height;
                    if (parentSize.Width > constraint.Width)
                        parentSize.Width = constraint.Width;
                    childSize = new Size(constraint.Width / scalefac, constraint.Height / scalefac);
                    child.Measure(childSize);
                }
                return parentSize;
            }
            /// <summary>
            /// Viewbox always sets the child to its desired size.  It then computes and applies a transformation
            /// from that size to the space available: Viewbox's own input size less child margin.
            /// 
            /// Viewbox also calls arrange on its child.
            /// </summary>
            /// <param name="arrangeSize">Size in which Border will draw the borders/background and children.</param>
            protected override Size ArrangeOverride(Size arrangeSize)
            {
                var child = InternalChild;
                if (child != null)
                {
                    var childSize = child.DesiredSize;
                    // Compute scaling factors from arrange size and the measured child content size
                    var scalefac = ComputeScaleFactor(arrangeSize, childSize, Stretch);
                    InternalTransform = new ScaleTransform(scalefac, scalefac);
                    childSize = new Size(arrangeSize.Width / scalefac, arrangeSize.Height / scalefac);
                    // Arrange the child to the desired size 
                    child.Arrange(new Rect(new Point(), childSize));
                    // return the size occupied by scaled child
                    arrangeSize.Width = scalefac * childSize.Width;
                    arrangeSize.Height = scalefac * childSize.Height;
                }
                return arrangeSize;
            }
            /// <summary>
            /// This is a helper function that computes scale factors depending on a target size and a content size
            /// </summary>
            /// <param name="availableSize">Size into which the content is being fitted.</param>
            /// <param name="contentSize">Size of the content, measured natively (unconstrained).</param>
            /// <param name="stretch">Value of the Stretch property on the element.</param>
            internal static double ComputeScaleFactor(Size availableSize, Size contentSize, Stretch stretch)
            {
                // Compute scaling factors to use for axes
                var scale = 1.0;
                var isConstrainedHeight = !Double.IsPositiveInfinity(availableSize.Height);
                if (isConstrainedHeight)
                {
                    // Compute scaling factors for both axes
                    scale = (DoubleUtil.IsZero(contentSize.Height)) ? 0.0 : availableSize.Height / contentSize.Height;
                }
                return scale;
            }
            #endregion Protected Methods
            //-------------------------------------------------------------------
            //
            //  Private Fields
            //
            //-------------------------------------------------------------------
            #region Private Fields
            private ContainerVisual _internalVisual;
            #endregion
        }
        static class DoubleUtil
        {
            internal const double DBL_EPSILON = 2.2204460492503131e-016; /* smallest such that 1.0+DBL_EPSILON != 1.0 */
            internal const float FLT_MIN = 1.175494351e-38F; /* Number close to zero, where float.MinValue is -float.MaxValue */
            public static bool IsZero(double value)
            {
                return Math.Abs(value) < 10.0 * DBL_EPSILON;
            }
        }
    }
