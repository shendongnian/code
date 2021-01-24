    public class Ages
    {
        int[] Ages {get;}
        public Ages (params int[] ages)
        {
            this.Ages = ages;
        }
        private void UpdateAges() =>
            for (int i=0; i<this.Ages.Length;i++) this.Ages[i]++;
    
        private string ToString() =>  
            string.Join(", ", 
                this.Ages.Select((age,i)=> $"Age{i} = {age}"));
    }
