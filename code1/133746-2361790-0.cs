    AdwizaControl control;
    case ControlType.Grid:
        control = ((AdwizaControl)pageView.Controls[i]).AdwizaWebControl;
        break;
    case ControlType.Hyperlink:
        control = ((AdwizaControl)pageView.Controls[i]).AdwizaWebControl;
        break;
    ...
