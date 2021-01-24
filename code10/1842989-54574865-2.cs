 lang-cs
public class Test
{
	private bool[,] bookingState = new bool[5,3];
	
	private void book_button_Click(object sender, EventArgs e) 
	{
		if (textBox1.Text == "")
        {
            MessageBox.Show("Name is required");
        }
        if (listBox1.SelectedIndex == -1 && listBox2.SelectedIndex == -1)
        {
            MessageBox.Show("Seat Number is required");
        }
        else if (listBox1.SelectedIndex == -1 || listBox2.SelectedIndex == -1)
        {
            MessageBox.Show("Seat Number is required");
        }
        
        // Now checking if the seat is booked
        string rowLetter = listBox1.GetItemText(listBox1.SelectedItem);
        // Insert checks for proper number format here
        int displayedRowSeatNumber = int.Parse(listBox2.GetItemText(listBox2.SelectedItem));
        // arrays are 0-based in C# so seat #1 would be at position 0.
        int rowSeatNumber = displayedRowSeatNumber - 1;
        
        // here you convert your row letter to row number for the booking array check
        // I'll use 1 for the example which is equivalent to B row
        int rowNumber = 1;
        
        if (bookingState[rowNumber, rowSeatNumber]) {
        	MessageBox.Show("Seat has been booked!");
        }
        else {
        	bookingState[rowNumber, rowSeatNumber] = true;
        	// You can use string interpolation here as well
        	richTextBox1.Text += textBox1.Text
        		+ " "
        		+ listBox1.GetItemText(listBox1.SelectedItem) 
        		+ listBox2.GetItemText(listBox2.SelectedItem)
        		+ "/n";
        }
	}
}
If you use a string array instead of a bool array you can save the name of the client there and use it to show who exactly booked the flight.
**UPD**: updated the answer with value preparation before checking.
