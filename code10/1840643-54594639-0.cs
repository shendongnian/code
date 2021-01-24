private bool IsVisibleFromOtherAssemblies(SyntaxNodeAnalysisContext context, SyntaxNode node)
{
    ISymbol declaredSymbol = GetDeclaredSymbol(context, node);
    var accessibility = declaredSymbol.DeclaredAccessibility;
    var visibility = ConstructVisibleFromOtherAssemblies(accessibility);
    var containingType = declaredSymbol.ContainingType;
    return IsSymbolAndContainingTypeVisible(visibility, containingType);
}
private static ISymbol GetDeclaredSymbol(SyntaxNodeAnalysisContext context, SyntaxNode node)
{
    if (node is BaseFieldDeclarationSyntax fieldDeclaration)
    {
        var firstField = fieldDeclaration.Declaration.Variables.First();
        return context.SemanticModel.GetDeclaredSymbol(firstField);
    }
    return context.SemanticModel.GetDeclaredSymbol(node);
}
private bool IsSymbolAndContainingTypeVisible(bool visibility, INamedTypeSymbol containingType)
{
    if (containingType == null)
    {
        return visibility;
    }
    return visibility && IsSymbolAndContainingTypeVisible(
               ConstructVisibleFromOtherAssemblies(containingType.DeclaredAccessibility),
               containingType.ContainingType);
}
private static bool ConstructVisibleFromOtherAssemblies(Accessibility accessibility) =>
    accessibility == Accessibility.Public ||
    accessibility == Accessibility.Protected ||
    accessibility == Accessibility.ProtectedOrInternal;
