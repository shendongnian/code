        using Microsoft.Owin.Hosting;
        using System;
        namespace YourConsoleAppProjectNamespace {
	        class Program {
		        static void Main(string[] args) {
			        WebApp.Start<Startup>("http://localhost:3333/");
			        Console.ReadLine(); // block main thread
		        }
	        }
        }
