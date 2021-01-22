        // FormatString property is shown in the designer, so you can provide
        // some designer support. If you are not using the desinger then you
        // either set it in the form/control ctor, or use a string directly
        // in the Format event.
        ListControl.FormatString = "{0}/{1}" ;
        
        private void listBoxCategory_Format(object sender, ListControlConvertEventArgs e)
            {
            	e.Value = string.Format(((ListBox)sender).FormatString,
        			((ClassOfListItem)e.ListItem).LongName,
        			((ClassOfListItem)e.ListItem).Key);
        }
