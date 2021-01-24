    while ((line = studentsReader.ReadLine()) != null)//ReadLine reads only one line from a file, e. g. v12345, Oliver, Queen
    {
        foreach (var lines in line.Split('\n'))//spiltting than single line by '\n' does nothing
        {
            /*Now you split by ',' not the iterator, which is lines,
             but an original string, which is line.
             But because you didn't actually split anything it makes no difference*/                        
             arr = line.Split(',');
             /*here you've got an array of strings {v12345, Oliver, Queen}
             On next iteration you'll read another line from a file and
             get the same array from another string, etc. And on each iteration
             the arr will be a new array, so after the last iteration you'll get
             the last line of file*/                      
        }
    }
