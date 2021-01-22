    using System;
    using System.Diagnostics;
    static class ArrayPref
    {
    const string Format = "{0,7:0.000} ";
    static void Main()
    {
        Jagged();
        Multi();
        Single();
    }
    static void Jagged()
    {
    const int dim = 100;
    for(var passes = 0; passes < 10; passes++)
    {
    var timer = new Stopwatch();
    timer.Start();
    var jagged = new int[dim][][];
    for(var i = 0; i < dim; i++)
    {
        jagged[i] = new int[dim][];
        for(var j = 0; j < dim; j++)
        {
            jagged[i][j] = new int[dim];
            for(var k = 0; k < dim; k++)
            {
                jagged[i][j][k] = i * j * k;
            }
        }
    }
    timer.Stop();
    Console.Write(Format,
    	(double)timer.ElapsedTicks/TimeSpan.TicksPerMillisecond);
    }
    Console.WriteLine();
    }
    static void Multi()
    {
    const int dim = 100;
    for(var passes = 0; passes < 10; passes++)
    {
    var timer = new Stopwatch();
    timer.Start();
    var multi = new int[dim,dim,dim];
    for(var i = 0; i < dim; i++)
    {
        for(var j = 0; j < dim; j++)
        {
            for(var k = 0; k < dim; k++)
            {
                multi[i,j,k] = i * j * k;
            }
        }
    }
    timer.Stop();
    Console.Write(Format,
    	(double)timer.ElapsedTicks/TimeSpan.TicksPerMillisecond);
    }
    Console.WriteLine();
    }
    static void Single()
    {
    const int dim = 100;
    for(var passes = 0; passes < 10; passes++)
    {
    var timer = new Stopwatch();
    timer.Start();
    var single = new int[dim*dim*dim];
    for(var i = 0; i < dim; i++)
    {
        for(var j = 0; j < dim; j++)
        {
            for(var k = 0; k < dim; k++)
            {
                single[i*dim*dim+j*dim+k] = i * j * k;
            }
        }
    }
    timer.Stop();
    Console.Write(Format,
    	(double)timer.ElapsedTicks/TimeSpan.TicksPerMillisecond);
    }
    Console.WriteLine();
    }
    }
