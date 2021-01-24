            List<Entity> list = findIndices("[s]AB[/s]23[sb]45[/sb]AB45ABABAB[a]test[/a]");
            
            for (var i = 0; i < list.Count; i++)
            {
                var l = list[i];
                
                Console.WriteLine("Text = " + l.Text);
                
                Console.WriteLine("IndexStartClean = " + l.IndexStartClean);
                Console.WriteLine("IndexEndClean = " + l.IndexEndClean);
                
                Console.WriteLine("---");
            }
