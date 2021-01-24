    @inject IWebHelper webHelper
    @inject IWorkContext workContext
    @inject IDateTimeHelper dateTimeHelper
    @inject IPermissionService permissionService
    @inject IEventPublisher eventPublisher
    @inject IHttpContextAccessor httpContextAccessor
    @inject CommonSettings commonSettings
    @inject LocalizationSettings localizationSettings
    @inject StoreInformationSettings storeInformationSettings
    @using System.Globalization;
    @using System.Text.Encodings.Web;
    @using Microsoft.AspNetCore.Http;
    @using Nop.Core.Domain.Customers;
    @using Nop.Web.Framework;
    @using Nop.Web.Framework.Events;
    @using Nop.Web.Framework.UI;
    @using Nop.Core;
    @using Nop.Core.Domain;
    @using Nop.Core.Domain.Common;
    @using Nop.Core.Domain.Localization;
    @using Nop.Services.Common;
    @using Nop.Services.Customers;
    @using Nop.Services.Events;
    @using Nop.Services.Helpers;
    @using Nop.Services.Security;
