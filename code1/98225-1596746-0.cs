I have not heard of a specific framework to accomplish that, but I would make each page a UserControl, or possibly a subclass of a control with the desired rendering logic. These page controls would all be members of the form, and added to its Controls collection as needed (or if there are too many of them, created as needed). They would have properties like Dock = DockStyle.Fill set in initialization. When changing pages:
void ChangePage(object sender, EventArgs e)
{
   Controls.Clear();
   Controls.Add(sender as Control);
}
