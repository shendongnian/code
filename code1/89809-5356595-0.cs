        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            object element = this.GetTemplateChild("PART_EditableTextBox");
            if (element != null)
            {
                textbox = element as TextBox;
                textbox.SelectionChanged += new RoutedEventHandler(textbox_SelectionChanged);
            }
        }
