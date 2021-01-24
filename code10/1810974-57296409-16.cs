    foreach (var solver in solvers)
    {
        try
        {
            Console.WriteLine(solver);
            Console.WriteLine(A.SolveIterative(B, solver));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
