    using System.Windows.Controls.Primitives;
    ...
    var isContainersGenerated = 
        ProgenyList.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated;
    
    if (!isContainersGenerated) return;
    //alternatively
    return if (!isContainersGenerated);
    
