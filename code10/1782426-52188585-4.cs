    @if (subSubMenuItem.Items.IsNullOrEmpty())
    {
        <a href="@calculateMenuUrl(subSubMenuItem.Url)">
            @if (!string.IsNullOrWhiteSpace(subSubMenuItem.Icon))
            {
                <i class="material-icons">@subSubMenuItem.Icon</i>
            }
            <span>@subSubMenuItem.DisplayName</span>
        </a>
    }
    else
    {
        <a href="javascript:void(0);" class="menu-toggle">
            @if (!string.IsNullOrWhiteSpace(subSubMenuItem.Icon))
            {
                <i class="material-icons">@subSubMenuItem.Icon</i>
            }
            <span>@subSubMenuItem.DisplayName</span>
        </a>
        <ul class="ml-menu">
            @foreach (var subsubSubMenuItem in subSubMenuItem.Items)
            {
                <li class="@(Model.ActiveMenuItemName == subsubSubMenuItem.Name ? "active" : "")">
                    <a href="@calculateMenuUrl(subsubSubMenuItem.Url)">
                        @subsubSubMenuItem.DisplayName
                    </a>
                </li>
            }
        </ul>
    }
