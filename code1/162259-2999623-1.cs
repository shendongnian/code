    public static void Main()
    {
      Task task = new Task();
      Console.WriteLine(task.AssignedOn); // OK
      Console.WriteLine(task.OccurredOn); // Compile Error
      IActivity activity = task as IActivity;
      if (activity != null)
      {
        Console.WriteLine(activity.AssignedOn); // Compile Error
        Console.WriteLine(activity.OccurredOn); // OK
      }
    }
