       public class AllowableCharactersTextBoxBehavior : Behavior<TextBox>
       {
         public static readonly DependencyProperty RegularExpressionProperty =
          DependencyProperty.Register("RegularExpression", typeof(string), typeof(AllowableCharactersTextBoxBehavior),
          new FrameworkPropertyMetadata("*"));
      public string RegularExpression
      {
         get
         {
            return (string)base.GetValue(RegularExpressionProperty);
         }
         set
         {
            base.SetValue(RegularExpressionProperty, value);
         }
      }
      public static readonly DependencyProperty MaxLengthProperty =
         DependencyProperty.Register("MaxLength", typeof(int), typeof(AllowableCharactersTextBoxBehavior),
         new FrameworkPropertyMetadata(int.MinValue));
      public int MaxLength
      {
         get
         {
            return (int)base.GetValue(MaxLengthProperty);
         }
         set
         {
            base.SetValue(MaxLengthProperty, value);
         }
      }
      protected override void OnAttached()
      {
         base.OnAttached();
         AssociatedObject.PreviewTextInput += OnPreviewTextInput;
         DataObject.AddPastingHandler(AssociatedObject, OnPaste);
      }
      private void OnPaste(object sender, DataObjectPastingEventArgs e)
      {
         if (e.DataObject.GetDataPresent(DataFormats.Text))
         {
            string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
            
            if (!IsValid(text))
            {
               e.CancelCommand();
            }
         }
         else
         {
            e.CancelCommand();
         }
      }
      void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
      {
         e.Handled = !IsValid(e.Text);
      }
      protected override void OnDetaching()
      {
         base.OnDetaching();
         AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
         DataObject.RemovePastingHandler(AssociatedObject, OnPaste);
      }
      private bool IsValid(string newText)
      {
         return !ExceedsMaxLength(newText) && Regex.IsMatch(newText, RegularExpression);
      }
      private bool ExceedsMaxLength(string newText)
      {
         if (MaxLength == 0) return false;
         return LengthOfModifiedText(newText) > MaxLength;
      }
      
      private int LengthOfModifiedText(string newText)
      {
         var countOfSelectedChars = this.AssociatedObject.SelectedText.Length;
         string text = this.AssociatedObject.Text;
         text = text.Remove(this.AssociatedObject.CaretIndex, countOfSelectedChars);
         return text.Length + newText.Length;
      }
    }
 
