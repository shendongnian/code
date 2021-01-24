    using Microsoft.Exchange.WebServices.Data;
    public class ItemEx : Item
    {
        public ItemEx(ExchangeService service)
            : base(service)
        {
        }
        internal ItemEx(ItemAttachment parentAttachment)
            : base(parentAttachment)
        {
        }
    }
