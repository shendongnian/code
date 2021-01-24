// Wire up the MouseEnter event when creating your buttons
button.MouseEnter += button_MouseEnter;
// Method that gets called
private void button_MouseEnter(object sender, EventArgs e)
{
    var button = sender as Button;
    ShipImage1.Location = button.Location;
}
