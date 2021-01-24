    public class StudentModel
    {
        public int StudentId {get;set;}
        public string StudentName {get;set;}
        public int ClassId {get;set;}
        public ClassModel StudentClass {get;set;}
    }
    
    public class ClassModel
    {
        public int ClassId {get;set;}
        public string ClassName {get;set;}
    }
