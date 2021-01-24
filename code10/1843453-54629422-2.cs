    void CompletionExample()
    {
        var code = @"using System;
    namespace NewConsoleApp
    {
    class NewClass
    {
        void Method()
        {
    fo // I want to get 'for' completion for this
        }
    }
    }";
        
        var completionIndex = code.LastIndexOf("fo") + 2;
        // Assume you have a method that create a workspace for you
        var workspace = CreateWorkspace("newSln", "newProj", code);
        var doc = workspace.CurrentSolution.Projects.First().Documents.First();
        var service = CompletionService.GetService(doc);
        var completionItems = service.GetCompletionsAsync(doc, completionIndex).Result.Items;
        foreach (var result in completionItems)
        {
            Console.WriteLine(result.DisplayText);
            Console.WriteLine(string.Join(",", result.Tags));
            Console.WriteLine();
        }
    }
