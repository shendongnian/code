        using System;
        using System.Collections.Generic;
        using System.Text;
        using System.IO;
        using Shell32; //"Microsoft Shell Control And Automation"
        
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Shell32.Shell oShell;
                    Shell32.Folder oFldr;
                    oShell = new Shell32.Shell();
                    oFldr = oShell.NameSpace(Shell32.ShellSpecialFolderConstants.ssfDESKTOP);//point to the desktop
        
                    foreach ( Shell32.FolderItem oFItm in oFldr.Items()) //get the shotrcuts
                    {
        
                        if (oFItm.IsLink)
                        {
                            Console.WriteLine("{0} {1} ", oFItm.Name, oFItm.Path);
        
                            bool isArchive = ((File.GetAttributes(oFItm.Path) & FileAttributes.Archive) == FileAttributes.Archive);
                            //bool isHidden = ((File.GetAttributes(oFItm.Path) & FileAttributes.Hidden) == FileAttributes.Hidden);
        
                            if (isArchive) //Warning, here you must define the condition for hide the shortcut. in this case only check if has set the Archive atribute. 
                            {
                                
                                //Now you can set  FileAttributes.Hidden atribute
                                //File.SetAttributes(oFItm.Path, File.GetAttributes(oFItm.Path) | FileAttributes.Hidden);
                            }
        
                        }
                        else
                        {
                            Console.WriteLine("{0} {1} ", oFItm.Name, oFItm.Path);
                        }
        
                    }
        
                    Console.ReadKey();
                }
            }
        }
