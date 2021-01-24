    public partial class Form1 : Form
    {
        DateTime[] monSchedule = new DateTime[3];
        private void Form1_Load(object sender, EventArgs e)
        {
            SetDefaultDTPValues();
        }
        private void SetDefaultDTPValues()
        {
            monStart.Value = DateTime.Parse("00:00");
            monEnd.Value = DateTime.Parse("00:00");
            monLunch.Value = DateTime.Parse("00:00");
            monSchedule[0] = monStart.Value;
            monSchedule[1] = monEnd.Value;
            monSchedule[2] = monLunch.Value;
        }
        private void DTP_ValueChanged(object sender, EventArgs e)
        {
            switch (sender)
            {
                case DateTimePicker dtp when dtp.Equals(monStart):
                    monSchedule[0] = dtp.Value;
                    break;
                case DateTimePicker dtp when dtp.Equals(monEnd):
                    monSchedule[1] = dtp.Value;
                    break;
                case DateTimePicker dtp when dtp.Equals(monLunch):
                    monSchedule[2] = dtp.Value;
                    break;
            }
        }
    }
