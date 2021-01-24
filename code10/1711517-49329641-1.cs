    public class window1
    {
    Window2 win2 = new Window2;
    public void btn_Click()
    {
        win2.showDialog();
        foreach (var item in win2.ItemList)
        {
            combobox1.Items.Add(item.tostring);
        }
    }
    }
