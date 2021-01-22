    class Renderer
    {
        Tenant _tenant;
    
        void Render(ContentType type)
        {
            switch (type)
            {
                case ContentType.JSON: 
                    _tenant.RenderJSON();
                    break;
                default:
                    _tenant.RenderHTML();
                    break;
            }
        }
    }
