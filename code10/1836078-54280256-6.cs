    var a = new Vector2(7, 3);
    var b = new Vector2(20, 7);
    var c = new Vector2(7, 10);
    var d = new Vector2(3, 7);
    var e = new Vector2(6.9f, 3); // Test for more than 270 deg.
    var f = new Vector2(7.1f, 3); // Test for small angle.
    var center = new Vector2(7, 7);
    PrintAngle(a); // ==>   0
    PrintAngle(b); // ==>  90
    PrintAngle(c); // ==> 180
    PrintAngle(d); // ==> 270
    PrintAngle(e); // ==> 358.5679
    PrintAngle(f); // ==>   1.432098
    void PrintAngle(Vector2 point)
    {
        Console.WriteLine(GetAngle(point, center));
    }
