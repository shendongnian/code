    foreach(string[] person in phonelist)
    {
     string[] newPerson = {"","","",""};
     int index = 0;
     for(int i=0; i<4; i++)
     {
      if(!String.IsNullOrEmpty(person[i])) newPerson[index++] = person[i];
     }
     person = newPerson;
    }
