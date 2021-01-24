    using System.Text.RegularExpressions;
    ...
    public class MegaGrid : Grid
    {
        private string zMegaRow = "";
        public string MegaRow
        {
            get { return zMegaRow; }
            set
            {
                zMegaRow = value;
                RowDefinitions.Clear();
                string value2 = Regex.Replace(value, @"\s+", "");
                string[] items = value2.Split(',');
                foreach (string item in items)
                {
                    // QUESTION: HOW TO CONVERT ITEM
                    // DIRECTLY FROM STRING INTO RowDefinition?
                    // Without Parsing the string
                    if (item == "*")
                    {
                        RowDefinitions.Add(
                          new RowDefinition { 
                            Height = new GridLength(1, GridUnitType.Star) }
                        );
                    }
                    else if (item == "auto")
                    {
                        RowDefinitions.Add(
                           new RowDefinition { Height = GridLength.Auto }
                        );
                    }
                }
            }
        } // MegaRow
        private string zMegaCol = "";
        public string MegaCol
        {
            get { return zMegaCol; }
            set
            {
                zMegaRow = value;
                ColumnDefinitions.Clear();
                string value2 = Regex.Replace(value, @"\s+", "");
                string[] items = value2.Split(',');
                foreach (string item in items)
                {
                    // QUESTION: HOW TO CONVERT ITEM
                    // DIRECTLY FROM STRING INTO ColumnDefinition?
                    // Without Parsing the string
                    if (item == "*")
                    {
                        ColumnDefinitions.Add(
                          new ColumnDefinition { 
                            Width = new GridLength(1, GridUnitType.Star) }
                        );
                    }
                    else if (item == "auto")
                    {
                        ColumnDefinitions.Add(
                           new ColumnDefinition { Width = GridLength.Auto }
                        );
                    }
                }
            }
        } // MegaCol
    } //MegaGrid
