    {
    ...
    
    btn.Click += (sender, ev) => {
        var b = Button as sender;
        if (b != null)
        {
            var tag = b.Tag; // assuming tag is keeping row/col in form R_C
            var dims = tag.Split('_');
            var row = int.Parse(dims[0]);
            var col = int.Parse(dims[1]);
    
            // get the buttons around, if any and make visible
            SetButtonVisible($"{row - 1}_{col})";
            SetButtonVisible($"{row}_{col - 1}");
            SetButtonVisible($"{row}_{col + 1}");
            SetButtonVisible($"{row + 1}_{col + 1}");
        }
    };
    
    }
    private void SetButtonVisible(string tag)
    {
       var button = form.Controls
                        .OfType<Button>()
                        .SingleOrDefault( c => c.Tag == tag );
       if ( button != null)
       {
          button.Visible = true;
       }     
    }
