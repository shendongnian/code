void Visit(ISomeView view, OrderDto dto) {
   if (dto.IsRush) {
        view.RenderRushOrder(dto);
   } else {
        view.RenderNornamlOrder(dto);
   }
}
