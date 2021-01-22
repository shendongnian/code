    public void LoadControl(ControlDestination controlDestination, string filename, object parameter)
    {
        try
        {
            // Get filename with extension
            string file = GetControlFileName(filename);
            // Check file exists
            if (!File.Exists(file))
                throw new FileNotFoundException();
            // Load control from file
            Control control = LoadControl(filename);
            // Check control extends BaseForm
            if (control is BaseForm)
            {
                // Set current application on user control
                ((BaseForm)control).CurrentApplication = this;
                ((BaseForm)control).Parameter = parameter;
                // Set web user control id
                control.ID = filename;
                Panel currentPanel = null;
                switch (controlDestination)
                {
                    case ControlDestination.Base:
                        // Set current panel to Base Content
                        currentPanel = pnlBaseContent;
                        // Set control in viewstate
                        this.BaseControl = filename;
                        break;
                    case ControlDestination.Menu:
                        // Set current panel to Menu Content
                        currentPanel = pnlMenuContent;
                        // Set control in ViewState
                        this.MenuBaseControl = filename;
                        break;
                }
                currentPanel.Controls.Clear();
                currentPanel.Controls.Add(control);
                UpdateMenuBasePanel();
                UpdateBasePanel();
            }
            else
            {
                throw new IncorrectInheritanceException();
            }
        }
        catch (Exception e)
        {
            HandleException(e);
        }
    }
    public void HandleException(Exception e)
    {
        if (e is FileNotFoundException
                || e is ArgumentNullException
                || e is HttpException
                || e is IncorrectInheritanceException)
        {
            // Load error control which shows big red cross
            LoadControl(ControlDestination.Menu, "~/Controls/Error.ascx", null);
            // Store error in database
            DHS.Core.DhsLogDatabase.WriteError(exception.ToString());
            // Show error in errorbox on master
            Master.ShowAjaxError(this, new CommandEventArgs("ajaxError", exception.ToString()));
        }
    }
