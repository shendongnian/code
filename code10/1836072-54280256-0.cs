    var a = new PointF(7, 3);
    var b = new PointF(20, 7);
    var c = new PointF(7, 10);
    var d = new PointF(3, 7);
    var center = new PointF(7, 7);
    var resA = Math.Atan2(a.Y - center.Y, a.X - center.X) * 180.0 / Math.PI + 90;
    var resB = Math.Atan2(b.Y - center.Y, b.X - center.X) * 180.0 / Math.PI + 90;
    var resC = Math.Atan2(c.Y - center.Y, c.X - center.X) * 180.0 / Math.PI + 90;
    var resD = Math.Atan2(d.Y - center.Y, d.X - center.X) * 180.0 / Math.PI + 90;
    Console.WriteLine(resA); // ==>  0
    Console.WriteLine(resB); // ==>  90
    Console.WriteLine(resC); // ==> 180
    Console.WriteLine(resD); // ==> 270
