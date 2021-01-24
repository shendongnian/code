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
        int rowSeatNumber = int.Parse(listBox2.GetItemText(listBox2.SelectedItem));
        
        // here you convert your row letter to row number for the booking array check
        // I'll use 1 for the example
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
If you use a string array instead of a bool array you can the name of the client there and usenit to show who exactly booked the flight.
