    public static void SetStudent( ref Student student )
    {
        student = new Student { Age = 69, Name="Botox" };
    }
    ...
    var a = new Student()
    var b = a;
    SetStudent(ref a);
    object.ReferenceEquals(a, b) // Should be false
