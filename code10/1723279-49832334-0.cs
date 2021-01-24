            while (!sr.EndOfStream){
        
            line = sr.ReadLine();
            for (int o = 0; o < line.Length; o++){
        
                dataGridView1[p, o].Value = line[o];
            }
            p++;
