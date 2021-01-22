    List<int> itemsToRemove = new List<int>(); // using System.Collections.Generic
    for (int i = 0; i <= listBox2.Items.Count; i++)
    {
        if (String.IsNullOrWhiteSpace(listBox2.Items[i].ToString())){
            itemsToRemove.Append(i);
        }
    }
    foreach (int i in itemsToRemove){
        listBox2.Items.RemoveAt(i);
    }
