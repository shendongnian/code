    public CustomContentDialogBox()
        {
            execute =
            o => //parametr "o" wyrażenia lambda
            {
                if (window == null)
                {
                    window = new Window();
                    window.Width = WindowWidth;
                    window.Height = WindowHeight;
                    if (Caption != null) window.Title = Caption;
                    window.Content = WindowContent;
                    //(some logic)
                    TraverseVisualTree(window); 
                    window = null;
                }
            };
        }
