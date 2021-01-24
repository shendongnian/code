    void addTask(Series s,  int who, DateTime startTime, 
                                     DateTime endTime, Color color, string task)
    {
        int pt = s.Points.AddXY(who, startTime, endTime);
        s.Points[pt].AxisLabel = names[who];
        s.Points[pt].Label = task;
        s.Points[pt].Color = color;
    }
