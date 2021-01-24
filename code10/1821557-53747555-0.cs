    Try this. 
    
           using System;
            namespace DirectoryTest
            {
                class Program
                {
                    static void Main(string[] args)
                    {
                        string sourceDirectory = @"D:\Projects\\Dot Net\ChurchAdmin\ChurchAdmin\api\Images\Announcements\\Church\ComitteeMeetings"
                        string destinationDirectory = @"D:\Projects\\Dot Net\ChurchAdmin\ChurchAdmin\api\Images\Announcements\\Church\Meetings"
                        try
                        {
                             System.IO.Directory.Move(sourceDirectory, destinationDirectory);
                        } 
                        catch (Exception eX)
                        {
                            Console.WriteLine(eX.Message);
                        }
                    }
                }
            }
