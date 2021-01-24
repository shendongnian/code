    public ActionResult AddAttributeValue(int productId, string value, int attributeDefinition)
        {
            if (value != null)
            {
                try
                {
                    var model = attributeValueRepository.Insert(new ProductAttributeValue()
                    {
                        IsCustom = true,
                        StringValue = value,
                        AttributeDefinitionId = attributeDefinition,
                    });
                    productAttributeRepository.Insert(new ProductAttribute()
                    {
                        AttributeValueId = model.Id,
                        ProductId = productId
                    });
                } catch
                {
                    AddErrorFlashMessage(T("Product.Attribute.AttributeValueError"));
                    return BadRequest();
                }
            }
            return Ok();
        }
