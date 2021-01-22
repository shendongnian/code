    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    namespace Hillinworks.Wpf.Controls
    {
        enum EllipsisPosition
        {
            Start,
            Middle,
            End
        }
        [DefaultProperty("Content")]
        [ContentProperty("Content")]
        internal class TextBlockTrimmer : ContentControl
        {
            private class TextChangedEventScreener : IDisposable
            {
                private readonly TextBlockTrimmer _textBlockTrimmer;
                public TextChangedEventScreener(TextBlockTrimmer textBlockTrimmer)
                {
                    _textBlockTrimmer = textBlockTrimmer;
                    s_textPropertyDescriptor.RemoveValueChanged(textBlockTrimmer.Content,
                                                                textBlockTrimmer.TextBlock_TextChanged);
                }
                public void Dispose()
                {
                    s_textPropertyDescriptor.AddValueChanged(_textBlockTrimmer.Content,
                                                             _textBlockTrimmer.TextBlock_TextChanged);
                }
            }
            private static readonly DependencyPropertyDescriptor s_textPropertyDescriptor =
                DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
            private const string ELLIPSIS = "...";
            private static readonly Size s_inifinitySize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            public EllipsisPosition EllipsisPosition
            {
                get { return (EllipsisPosition)GetValue(EllipsisPositionProperty); }
                set { SetValue(EllipsisPositionProperty, value); }
            }
            public static readonly DependencyProperty EllipsisPositionProperty =
                DependencyProperty.Register("EllipsisPosition",
                                            typeof(EllipsisPosition),
                                            typeof(TextBlockTrimmer),
                                            new PropertyMetadata(EllipsisPosition.End,
                                                                 TextBlockTrimmer.OnEllipsisPositionChanged));
            private static void OnEllipsisPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((TextBlockTrimmer)d).OnEllipsisPositionChanged((EllipsisPosition)e.OldValue,
                                                                 (EllipsisPosition)e.NewValue);
            }
            private string _originalText;
            private Size _constraint;
            protected override void OnContentChanged(object oldContent, object newContent)
            {
                var oldTextBlock = oldContent as TextBlock;
                if (oldTextBlock != null)
                {
                    s_textPropertyDescriptor.RemoveValueChanged(oldTextBlock, TextBlock_TextChanged);
                }
                if (newContent != null && !(newContent is TextBlock))
                    // ReSharper disable once LocalizableElement
                    throw new ArgumentException("TextBlockTrimmer access only TextBlock content", nameof(newContent));
                var newTextBlock = (TextBlock)newContent;
                if (newTextBlock != null)
                {
                    s_textPropertyDescriptor.AddValueChanged(newTextBlock, TextBlock_TextChanged);
                    _originalText = newTextBlock.Text;
                }
                else
                    _originalText = null;
                base.OnContentChanged(oldContent, newContent);
            }
        
            private void TextBlock_TextChanged(object sender, EventArgs e)
            {
                _originalText = ((TextBlock)sender).Text;
                this.TrimText();
            }
            protected override Size MeasureOverride(Size constraint)
            {
                _constraint = constraint;
                return base.MeasureOverride(constraint);
            }
            protected override Size ArrangeOverride(Size arrangeBounds)
            {
                var result = base.ArrangeOverride(arrangeBounds);
                this.TrimText();
                return result;
            }
            private void OnEllipsisPositionChanged(EllipsisPosition oldValue, EllipsisPosition newValue)
            {
                this.TrimText();
            }
            private IDisposable BlockTextChangedEvent()
            {
                return new TextChangedEventScreener(this);
            }
            private static double MeasureString(TextBlock textBlock, string text)
            {
                textBlock.Text = text;
                textBlock.Measure(s_inifinitySize);
                return textBlock.DesiredSize.Width;
            }
            private void TrimText()
            {
                var textBlock = (TextBlock)this.Content;
                if (textBlock == null)
                    return;
                if (DesignerProperties.GetIsInDesignMode(textBlock))
                    return;
                var freeSize = _constraint.Width
                               - this.Padding.Left
                               - this.Padding.Right
                               - textBlock.Margin.Left
                               - textBlock.Margin.Right;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (freeSize <= 0)
                    return;
                using (this.BlockTextChangedEvent())
                {
                    // this actually sets textBlock's text back to its original value
                    var desiredSize = TextBlockTrimmer.MeasureString(textBlock, _originalText);
                    if (desiredSize <= freeSize)
                        return;
                    var ellipsisSize = TextBlockTrimmer.MeasureString(textBlock, ELLIPSIS);
                    freeSize -= ellipsisSize;
                    var epsilon = ellipsisSize / 3;
                    if (freeSize < epsilon)
                    {
                        textBlock.Text = _originalText;
                        return;
                    }
                    var segments = new List<string>();
                    var builder = new StringBuilder();
                    switch (this.EllipsisPosition)
                    {
                        case EllipsisPosition.End:
                            TextBlockTrimmer.TrimText(textBlock, _originalText, freeSize, segments, epsilon, false);
                            foreach (var segment in segments)
                                builder.Append(segment);
                            builder.Append(ELLIPSIS);
                            break;
                        case EllipsisPosition.Start:
                            TextBlockTrimmer.TrimText(textBlock, _originalText, freeSize, segments, epsilon, true);
                            builder.Append(ELLIPSIS);
                            foreach (var segment in ((IEnumerable<string>)segments).Reverse())
                                builder.Append(segment);
                            break;
                        case EllipsisPosition.Middle:
                            var textLength = _originalText.Length / 2;
                            var firstHalf = _originalText.Substring(0, textLength);
                            var secondHalf = _originalText.Substring(textLength);
                            freeSize /= 2;
                            TextBlockTrimmer.TrimText(textBlock, firstHalf, freeSize, segments, epsilon, false);
                            foreach (var segment in segments)
                                builder.Append(segment);
                            builder.Append(ELLIPSIS);
                            segments.Clear();
                            TextBlockTrimmer.TrimText(textBlock, secondHalf, freeSize, segments, epsilon, true);
                            foreach (var segment in ((IEnumerable<string>)segments).Reverse())
                                builder.Append(segment);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                    textBlock.Text = builder.ToString();
                }
            }
            private static void TrimText(TextBlock textBlock,
                                         string text,
                                         double size,
                                         ICollection<string> segments,
                                         double epsilon,
                                         bool reversed)
            {
                while (true)
                {
                    if (text.Length == 1)
                    {
                        var textSize = TextBlockTrimmer.MeasureString(textBlock, text);
                        if (textSize <= size)
                            segments.Add(text);
                        return;
                    }
                    var halfLength = Math.Max(1, text.Length / 2);
                    var firstHalf = reversed ? text.Substring(halfLength) : text.Substring(0, halfLength);
                    var remainingSize = size - TextBlockTrimmer.MeasureString(textBlock, firstHalf);
                    if (remainingSize < 0)
                    {
                        // only one character and it's still too large for the room, skip it
                        if (firstHalf.Length == 1)
                            return;
                        text = firstHalf;
                        continue;
                    }
                    segments.Add(firstHalf);
                    if (remainingSize > epsilon)
                    {
                        var secondHalf = reversed ? text.Substring(0, halfLength) : text.Substring(halfLength);
                        text = secondHalf;
                        size = remainingSize;
                        continue;
                    }
                    break;
                }
            }
        }
    }
