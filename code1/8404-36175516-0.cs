               try
                {
                    control_name.Click -= event_Click;
                    main_browser.Document.Click += Document_Click;
                }
                catch(Exception exce)
                {
                    main_browser.Document.Click += Document_Click;
                }
