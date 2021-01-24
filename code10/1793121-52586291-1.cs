    private string GetTrimbleMark(string name)
    {
        var marksfile = (string)_appSettings.GetValue("MarksFile", typeof(string));
            _marks = new dsMarks();
            try
            {
                if (File.Exists(marksfile))
                {
                    using (var reader = new FileStream(marksfile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        _marks.ReadXml(reader);
                    }
                }
            }
            catch (Exception)
            {
                _marks = null;
                throw;
            }
        var row = _marks.Mark.FindByName(name);
        var mark = row.TimeMark;
        return mark;
    }
