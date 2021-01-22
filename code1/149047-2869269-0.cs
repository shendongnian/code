            var m_toolbar = this.Application.CommandBars.Add("WpfAddIn",
                Office.MsoBarPosition.msoBarTop, false, true);
            var mainMenu = (Office.CommandBarPopup)m_toolbar.Controls
                .Add(Office.MsoControlType.msoControlPopup, 
                missing, missing, missing, true);
            mainMenu.Caption = "Main menu";
            var subMenu1 = (Office.CommandBarButton)mainMenu.Controls
                .Add(Office.MsoControlType.msoControlButton, 
                missing, missing, missing, true);
            subMenu1.Caption = "Sub menu 1";
            subMenu1.FaceId = 1958;
            var subMenu2 = (Office.CommandBarPopup)mainMenu.Controls
                .Add(Office.MsoControlType.msoControlPopup,
                missing, missing, missing, true);
            subMenu2.BeginGroup = true;
            subMenu2.Caption = "Sub menu 2";
            var subMenu2Button = (Office.CommandBarButton)subMenu2.Controls
                .Add(Office.MsoControlType.msoControlButton,
                missing, missing, missing, true);
            subMenu2Button.Caption = "Sub menu 1";
            subMenu2Button.FaceId = 1958;
            m_toolbar.Visible = true;
