        private void OnClick(object sender, EventArgs eventArgs)
        {
            GridEl thisButton = sender as GridEl;
            Console.WriteLine($"Row: {thisButton.R}; Column: {thisButton.C}");
        }
