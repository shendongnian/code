    private void CheckDuplicateDescription(T template)
            {
                var propDescription = GetPropertyNameDescription();//asuming you have the name of the Description property
                var value = GetValueDescription(template, propDescription);
                var condition = GetCondition(propDescription, value);
                if (_dbSet.Any(condition))
                {
                    throw new DuplicatePropertyException("Description",
                        string.Format(Messages.alreadyExistsWithValue, template.Descrip.Trim()));
                }
            }
