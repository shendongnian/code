    public PointF[][] MultiplyLine(PointF[] line, int width, int num)
    {
        if (num == 1) return new PointF[][] { line };
        if (num < 1) throw new ArgumentOutOfRangeException();
        if (line.Length < 2) return Enumerable.Range(0, num)
                      .Select(x => line).ToArray();
        Func<float, float, PointF> normVec = (x, y) => {
            float len = (float)Math.Sqrt((double)(x * x + y * y));
            return len == 0 ? new PointF(1f, 0f) : new PointF(x / len, y / len);
        };
        PointF[][] newLines = Enumerable.Range(0, num)
                      .Select(x => new PointF[line.Length]).ToArray();
        float numinv = 1f / (float)(num - 1), cor = 0f;
        PointF vec1 = PointF.Empty, vec2 = PointF.Empty, vec3 = PointF.Empty;
        int j = -1, i = -1;
        foreach (PointF p in line)
        {
            bool first = j == -1, last = j == line.Length - 2; j++;
            if (!last)
                vec1 = normVec(line[j + 1].Y - p.Y, -line[j + 1].X + p.X);
            if (!first)
                vec2 = normVec(-line[j - 1].Y + p.Y, line[j - 1].X - p.X);
            if (!first && !last)
            {
                vec3 = normVec(vec1.X + vec2.X, vec1.Y + vec2.Y);
                cor = (float)Math.Sin((Math.PI - 
                      Math.Acos(vec1.X * vec2.X + vec1.Y * vec2.Y)) / 2);
                cor = cor == 0 ? 1 : cor;
                vec3 = new PointF(vec3.X / cor, vec3.Y / cor);
            }
            i = -1;
            foreach (PointF[] newLine in newLines)
            {
                i++; cor = (float)width * ((float)i * numinv - 0.5f);
                vec1 = first ? vec1 : last ? vec2 : vec3;
                newLine[j] = new PointF(vec1.X * cor + p.X, vec1.Y * cor + p.Y);
            }
        }
        
        return newLines;
    }
