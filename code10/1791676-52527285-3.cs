    host.Open();
    Console.WriteLine("The service is ready at {0}", baseAddress);
    Console.WriteLine("Press <Enter> to stop the service.");
    Console.ReadLine();  // <-------- program waits here
    // Close the ServiceHost.
    host.Close();
