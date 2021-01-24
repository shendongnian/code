    public class MyLayout : TableLayout
    {
        public CheckBox PeopleIsOn = new CheckBox() { Text = "On/Off" };
        public Label PeopleLabel = new Label { Text = "People" };
        public CheckBox OtherIsOn = new CheckBox() { Text = "On/Off" };
        public Label OtherLabel = new Label { Text = "Other" };
        public MyLayout()
        {
            layout.Rows.Add(new TableRow(
                new TableCell(PeopleLabel, true), // the true argument of TableCell is important in the cells of the first row
                new TableCell(PeopleIsOn, true)
            ));
            layout.Rows.Add(new TableRow(
                OtherLabel, // from second row the parameter is no longer needed
                OtherIsOn
            ));
        }
    }
