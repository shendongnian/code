    using System;
    using Xamarin.Forms;
    namespace MyApp.Controls
    {
        public class CustomFrame : Frame
        {
            // ---------------------------------------------------------------------------------------------------------------
            public static readonly BindableProperty CornerRadiusTopLeftProperty = BindableProperty.Create(
                propertyName: "CornerRadiusTopLeft",
                returnType: typeof(bool),
                declaringType: typeof(CustomFrame),
                defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay
            );
            public bool CornerRadiusTopLeft
            {
                get { return (bool)GetValue(CornerRadiusTopLeftProperty); }
                set { base.SetValue(CornerRadiusTopLeftProperty, value); }
            }
            // ---------------------------------------------------------------------------------------------------------------
            public static readonly BindableProperty CornerRadiusTopRightProperty = BindableProperty.Create(
                propertyName: "CornerRadiusTopRight",
                returnType: typeof(bool),
                declaringType: typeof(CustomFrame),
                defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay
            );
            public bool CornerRadiusTopRight
            {
                get { return (bool)GetValue(CornerRadiusTopRightProperty); }
                set { base.SetValue(CornerRadiusTopRightProperty, value); }
            }
            // ---------------------------------------------------------------------------------------------------------------
            public static readonly BindableProperty CornerRadiusBottomLeftProperty = BindableProperty.Create(
                propertyName: "CornerRadiusBottomLeft",
                returnType: typeof(bool),
                declaringType: typeof(CustomFrame),
                defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay
            );
            public bool CornerRadiusBottomLeft
            {
                get { return (bool)GetValue(CornerRadiusBottomLeftProperty); }
                set { base.SetValue(CornerRadiusBottomLeftProperty, value); }
            }
            // ---------------------------------------------------------------------------------------------------------------
            public static readonly BindableProperty CornerRadiusBottomRightProperty = BindableProperty.Create(
                propertyName: "CornerRadiusBottomRight",
                returnType: typeof(bool),
                declaringType: typeof(CustomFrame),
                defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay
            );
            public bool CornerRadiusBottomRight
            {
                get { return (bool)GetValue(CornerRadiusBottomRightProperty); }
                set { base.SetValue(CornerRadiusBottomRightProperty, value); }
            }
        }
    }
