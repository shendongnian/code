    //The CheckBoxList name is boxes
    int CA = Convert.ToInt32(CheckAmount.Text);
    Random rng = new Random();
    int x = 0;
    for (int y = CA; y != 0; y--)
    foreach (CheckBox i in boxes.Controls)
    {
         x = rng.Next(1, boxes.Length + 1); //have to add 1 or it will never pick the last box
         if(boxes[boxes.Controls.IndexOf(i)] == x - 1)
         {
              i.Checked = true;
              y--;
         }
         else
         {
              continue;
         }
    }
