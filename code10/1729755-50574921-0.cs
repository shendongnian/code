    @using Microsoft.AspNetCore.Blazor.Components
    @inject Microsoft.AspNetCore.Blazor.Services.IUriHelper UriHelper
    
    <li class="m-menu__item @(Active ? "m-menu__item--active" : "")">
        <a href=@Url class="m-menu__link ">
            <span class="m-menu__item-here"></span>
            <i class="m-menu__link-icon @Icon"></i>
            <span class="m-menu__link-text">@Text</span>
        </a>
    </li>
    
    @functions {
        protected override void OnInit()
        {
            UriHelper.OnLocationChanged += OnLocationChanges;
        }
        [Parameter]
        private string Url { get; set; }
        [Parameter]
        private string Icon { get; set; }
        [Parameter]
        private string Text { get; set; }
        private bool Active = false;
        private void OnLocationChanges(object sender, string location)
        {
            Active = location.Contains(Url);
            StateHasChanged();
        }
    }
