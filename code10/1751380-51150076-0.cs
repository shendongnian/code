	/// <summary>
	/// Finds the entity set that a navigation property targets.
	/// </summary>
	/// <param name="property">The navigation property.</param>
	/// <returns>The entity set that the navigation propertion targets, or null if no such entity set exists.</returns>
	/// TODO: change null logic to using UnknownEntitySet
	public override IEdmNavigationSource FindNavigationTarget(IEdmNavigationProperty property)
	{
		return null;
	}
