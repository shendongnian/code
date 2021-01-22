    public class Evaluation
    {
        public Int32 Id { get; set; }
        public String Comment { get; set; }
        public virtual void Save()
        {
            // Save the common information.
            this.SaveToDatabase(this.Id);
            this.SaveToDatabase(this.Comment);
        }
        private void SaveToDatabase(Object value)
        {
            // Left as an exercise for the reader... :D
        }
    }
    
    public class EvaluationType1 : Evaluation
    {
        public String Foo { get; set; }
        public override void Save()
        {
            // Save the common information.
            base.Save();
    
            // Save the specific information here.
            this.SaveToDatabase(this.Foo);
        }
    }
    public class EvaluationType2 : Evaluation
    {
        public String Bar { get; set; }
        public override void Save()
        {
            // Save the common information.
            base.Save();
    
            // Save the specific information here.
            this.SaveToDatabase(this.Bar);
        }
    }
