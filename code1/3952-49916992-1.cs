    public static List<PointF> RemoveDuplicates(List<PointF> listPoints)
    {
        List<PointF> result = new List<PointF>();
        for (int i = 0; i < listPoints.Count; i++)
        {
            if (!result.Contains(listPoints[i]))
                result.Add(listPoints[i]);
            }
            return result;
        }
