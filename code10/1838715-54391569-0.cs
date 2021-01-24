        private void toggleButtons(int start, int end, bool trueOrFalse)
        {
            for(int x=start; x <= end; x++)
            {
                this.Controls.OfType<Button>().Where(b => b.Name == "button" + x.ToString()).SingleOrDefault().Visible = trueOrFalse;
            }
        }
