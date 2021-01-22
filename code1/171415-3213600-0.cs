    class Program
    {
        enum ReportStatus
        {
            Assigned = 1,
            Analyzed = 2,
            Written = 3,
            Reviewed = 4,
            Finished = 5,
        }
        static void Main(string[] args)
        {
            WriteValues(Enum.GetValues(typeof(ReportStatus)));
            ReportStatus[] values = new ReportStatus[] {
                ReportStatus.Assigned,
                ReportStatus.Analyzed,
                ReportStatus.Written,
                ReportStatus.Reviewed,
                ReportStatus.Finished,
            };
            WriteValues(values);
        }
        static void WriteValues(Array values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }
        static void WriteValues(ReportStatus[] values)
        {
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
