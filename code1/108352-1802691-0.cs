           public static void LoadRefeferenceAssembly(string AssemblyCollectionName)
       {
           AssemblyDefinitionProviderClient alc = new AssemblyDefinitionProviderClient();
           
           alc.getAssemblyListCompleted += alc_getAssemblyListCompleted;
           alc.getAssemblyListAsync(AssemblyCollectionName);
       }
       static void alc_getAssemblyListCompleted(object sender, getAssemblyListCompletedEventArgs e)
       {
           if (e.Result == null || e.Error != null)
           {
               throw new ArgumentException("Assembly for cache error");
           }
           foreach (AssemblyDescription description in e.Result)
           {
               if (ReferencedAssemblies.Keys.Contains(description.name)) continue;
               var ass = new ReferencedAssembly { Name = description.name, PercentLoaded = 0.0, Uri = new Uri(description.url, description.kind), State = ReferencedAssemblyStates.None };
               if (description.isMainAssembly)
               {
                   _currentMainAssembly = description.name;
                   ass.MainUIElementName = description.MainUIElementString;
               }
               ReferencedAssemblies.Add(description.name,ass);
           }
           beginCaching();
       }
       private static void beginCaching()
       {
           var tocache = Instance._ReferencedAssemblies.Values.FirstOrDefault(re => re.State == ReferencedAssemblyStates.None);
           if (tocache == null)
           {
               changeContent();
               return;
           }
           var wc = new WebClient();
           //progress here
           wc.OpenReadCompleted += (sender, e) =>
                                       {
                                           if (e.Result != null || e.Error == null)
                                           {
                                               AssemblyPart apart = new AssemblyPart();
                                               tocache.AssemblyPart = apart.Load(e.Result);
                                               tocache.State = ReferencedAssemblyStates.Done;
                                               setStatus(tocache.Name + "Loaded");
                                           }
                                           else
                                           {
                                               tocache.Error = e.Error;
                                               tocache.State = ReferencedAssemblyStates.Error;
                                               setStatus(tocache.Name + "Error by Loading");
                                           }
                                           beginCaching();
                                       };
           wc.OpenReadAsync(tocache.Uri);
          
       }
