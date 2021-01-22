    var widget = repository[filePath];
    repository.Remove(filePath);
    widget.FilePath = newFilePath;
    repository.Add(widget);
     EDIT: this could probably be implemented as a method on the
     dictionary as well.
       public void UpdatePath( Widget widget, string newPath )
       {
           if (string.IsNullOrEmpty(newPath))
              throw new ArgumentNullException( "newPath" );
            
           var widget = this.ContainsKey(widget.FilePath)
                                 ? this[widget.FilePath]
                                 : null;
           
           if (widget != null)
           {           
               this.Remove(widget.FilePath);
           }
           widget.FilePath = newPath;
           this.Add( widget );
        }
