    public partial class Form1 : Form {
      private System.Media.SoundPlayer alarm;
      protected override OnFormClosing(CancelEventArgs e) {
        if (alarm != null) alarm.Stop();
      }
    }
