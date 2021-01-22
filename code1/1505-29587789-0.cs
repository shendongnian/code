    ArrayList arrayList;
    //Add some Members :)
    arrayList.Add("ali");
    arrayList.Add("hadi");
    arrayList.Add("ali");
    //Remove duplicates from array
      for (int i = 0; i < arrayList.Count; i++)
        {
           for (int j = i + 1; j < arrayList.Count ; j++)
               if (arrayList[i].ToString() == arrayList[j].ToString())
                     arrayList.Remove(arrayList[j]);
