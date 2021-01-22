[EventSubscription("StatusChanged", ThreadOption=ThreadOption.UserInterface)]
public void OnStatusChanged(object sender, StatusEventArgs e)
{
   this.statusLabel.Text = e.Text;
   if (e.ProgressPercentage != -1)
   {
      this.progressBar.Visible = true;
      this.progressBar.Value = e.ProgressPercentage;
   }
}
