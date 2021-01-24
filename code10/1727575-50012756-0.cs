    foreach(Grade gr in Grades)
    {
       if(points <= gr.maxPoints)
       {
          grade = gr.letter.ToString();
          break;
       }
    }
    MessageBox.Show(grade); 
